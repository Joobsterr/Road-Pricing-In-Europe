# BEFORE YOU CAN USE THIS SCRIPT, CHANGE THE FOLLOWING VARIABLES:
# host (in RabbitMQ) --> place where your RabbitMQ runs (locally -> localhost)
# sumoExecutable --> Path to your installation of SUMO-gui.exe.
# sumoConfigFile --> Path to your sumo.cfg file.

import os, sys
import traci
import traci.constants as tc
import pika#chu
import sys

### Methods
# RabbitMQ data producer method
def sendData(carId, lat: str, lon: str):
    exchangeKey = 'sumoData'
    routingKey = 'dataService'
    message = "Vehicle [" + carId + "] lat: " + lat + " || lon: " + lon

    connection = pika.BlockingConnection(pika.ConnectionParameters(host='localhost'))
    channel = connection.channel()

    channel.exchange_declare(exchange=exchangeKey, exchange_type='topic')

    channel.basic_publish(exchange=exchangeKey, routing_key=routingKey, body=message)
    connection.close()

### Main
# Checks if SUMO is toegankelijk via de environment variables
if 'SUMO_HOME' in os.environ:
    tools = os.path.join(os.environ['SUMO_HOME'], 'tools')
    sys.path.append(tools)
else:
    sys.exit("please declare environment variable 'SUMO_HOME'")

# Specificieerd de locatie van SUMO en het configuratie bestand
sumoExecutable = "D:/Program Files (x86)/Eclipse/Sumo/bin/SUMO-gui.exe"
sumoConfigFile = "D:/GIT-projects/S6/Road-Pricing-In-Europe/TraCI Script/minimap.sumo.cfg"
simulationDuration = 1000

sumoCmd = [sumoExecutable, "-c", sumoConfigFile]

# Start het TraCI script
traci.start(sumoCmd)
step = 0
while step < simulationDuration:
    traci.simulationStep()
    # Als de stap een meervoud is van 10, dan stuurt hij de data op
    if step%10 == 0:
        for carId in traci.vehicle.getIDList():
            # Haalt de specifieke data van het voertuig op die gewenst is
            x, y = traci.vehicle.getPosition(carId)
            lon, lat = traci.simulation.convertGeo(x, y)
            # Stuurt de data via RabbitMQ naar de data processing service
            sendData(str(carId), str(lat), str(lon))
    step += 1

traci.close()

