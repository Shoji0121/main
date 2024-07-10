#!/bin/bash

sshpass -p 'torizon' ssh -o UserKnownHostsFile=/dev/null -o StrictHostKeyChecking=no torizon@host.docker.internal "docker exec -i torizon-weston-1 weston-touch-calibrator /sys/devices/platform/soc/2100000.bus/21a4000.i2c/i2c-1/1-002c/input/input0/event0"
# # Define variables
# SSH_USER="torizon"
# SSH_HOST="172.16.3.101"
# DOCKER_CONTAINER_ID="torizon-weston-1"
# SSH_PASS="torizon"
# CALIBRATOR_COMMAND="weston-touch-calibrator /sys/devices/platform/soc/2100000.bus/21a4000.i2c/i2c-1/1-002c/input/input0/event0"

# # Execute the command via SSH
# CONTAINER_ID=$(sshpass -p ${SSH_PASS} ssh ${SSH_USER}@${SSH_HOST} "docker ps -qf name=${CONTAINER_NAME}")

# sshpass -p ${SSH_PASS} ssh ${SSH_USER}@${SSH_HOST} "docker exec -i ${CONTAINER_ID} ${CALIBRATOR_COMMAND}"
