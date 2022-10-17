# BEFORE YOU CAN USE THIS SCRIPT, CHANGE THE FOLLOWING VARIABLES:
# host (in RabbitMQ) --> place where your RabbitMQ runs (locally -> localhost)
# sumoExecutable --> Path to your installation of SUMO-gui.exe.
# sumoConfigFile --> Path to your sumo.cfg file.

import os, sys
import traci
import traci.constants as tc
import pika#chu
import sys

# Methods
def sendData(carId, lat: str, lon: str):
    exchangeKey = 'sumoData'
    routingKey = 'dataService'
    message = "Vehicle [" + carId + "] lat: " + lat + " || lon: " + lon

    connection = pika.BlockingConnection(pika.ConnectionParameters(host='localhost'))
    channel = connection.channel()

    channel.exchange_declare(exchange=exchangeKey, exchange_type='topic')

    channel.basic_publish(exchange=exchangeKey, routing_key=routingKey, body=message)
    connection.close()

# Main
if 'SUMO_HOME' in os.environ:
    tools = os.path.join(os.environ['SUMO_HOME'], 'tools')
    sys.path.append(tools)
else:
    sys.exit("please declare environment variable 'SUMO_HOME'")

sumoExecutable = "D:/Program Files (x86)/Eclipse/Sumo/bin/SUMO-gui.exe"
sumoConfigFile = "D:/GIT-projects/S6/Road-Pricing-In-Europe/TraCI Script/minimap.sumo.cfg"
simulationDuration = 1000

sumoCmd = [sumoExecutable, "-c", sumoConfigFile]


traci.start(sumoCmd)
step = 0
while step < simulationDuration:
    traci.simulationStep()
    if step%10 == 0:
        for carId in traci.vehicle.getIDList():
            x, y = traci.vehicle.getPosition(carId)
            lon, lat = traci.simulation.convertGeo(x, y)
            sendData(str(carId), str(lat), str(lon))
    step += 1

traci.close()

