# BEFORE YOU CAN USE THIS SCRIPT, CHANGE THE FOLLOWING VARIABLES:
# host (in RabbitMQ) --> place where your RabbitMQ runs (locally -> localhost)
# sumoExecutable --> Path to your installation of SUMO-gui.exe.
# sumoConfigFile --> Path to your sumo.cfg file.

import os, sys
import traci
import traci.constants as tc
import pika#chu
import sys
import json
from datetime import datetime

class dataModel: 
    def __init__(self, carId, lat, lon, dateTimeNow, routeId, laneMaxSpeedMs, vehicleTypeName): 
        self.carId = carId
        self.lat = lat
        self.lon = lon
        self.dateTimeNow = dateTimeNow
        self.routeId = routeId
        self.laneMaxSpeedMs = laneMaxSpeedMs
        self.vehicleTypeName = vehicleTypeName

    def dump(self):
        return {'carId': int(self.carId),
                               'latitude': self.lat,
                               'longitude': self.lon,
                               'timeStamp': self.dateTimeNow,
                               'routeId': int(self.routeId),
                               'laneMaxSpeedMs': int(self.laneMaxSpeedMs),
                               'vehicleTypeName': self.vehicleTypeName}
        
# Methods
def sendData(messageBody):
    exchangeKey = 'sumoData'
    routingKey = 'dataService'

    connection = pika.BlockingConnection(pika.ConnectionParameters(host='localhost'))
    channel = connection.channel()

    channel.exchange_declare(exchange=exchangeKey, exchange_type='topic')

    channel.basic_publish(exchange=exchangeKey, routing_key=routingKey, body=json.dumps([o.dump() for o in messageBody], indent=3))
    connection.close()

# Main
if 'SUMO_HOME' in os.environ:
    tools = os.path.join(os.environ['SUMO_HOME'], 'tools')
    sys.path.append(tools)
else:
    sys.exit("please declare environment variable 'SUMO_HOME'")


# Nardo's laptop config
# sumoExecutable = "D:/Program Files (x86)/Eclipse/Sumo/bin/SUMO-gui.exe"

# Nardo's PC config
sumoExecutable = "D:/Program Files (x86)/Eclipse/Sumo/bin/SUMO-gui.exe"


sumoConfigFile = "minimap.sumo.cfg"
maxVehiclesInSimulation = "500"
simulationDuration = 50000

sumoCmd = ([sumoExecutable, 
            "-c", sumoConfigFile, 
            "--max-num-vehicles", maxVehiclesInSimulation])

traci.start(sumoCmd)
step = 0
while step < simulationDuration:
    traci.simulationStep()
    if step%10 == 0:
        dateTimeNowString = datetime.now().strftime("%d-%m-%Y %H:%M:%S")
        vehicleDataList = []
        for carId in traci.vehicle.getIDList():
            routeString = traci.vehicle.getRouteID(carId)
            routeId = routeString[1:]
            x, y = traci.vehicle.getPosition(carId)
            lon, lat = traci.simulation.convertGeo(x, y)
            laneId = traci.vehicle.getLaneID(carId)
            laneMaxSpeedMs = traci.lane.getMaxSpeed(laneId)
            vehicleTypeName = traci.vehicle.getTypeID(carId)
            vehicleDataList.append(dataModel(carId, lat, lon, dateTimeNowString, routeId, laneMaxSpeedMs, vehicleTypeName))
        
        sendData(vehicleDataList)
    step += 1
traci.close()