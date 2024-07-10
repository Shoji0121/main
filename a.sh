#!/bin/bash
dirs=("/var/rootdirs/media/USB_1" "/var/rootdirs/media/USB_2")
devices=("/dev/sda" "/dev/sdc" "/dev/sdb" "/dev/sdd")

for dir in "${dirs[@]}"; do
    if mountpoint -q "$dir"; then
        sudo umount "$dir"
    fi

    if [ -b "$dir" ]; then
        sudo rm -rf "$dir"
    fi

    mkdir -p "$dir"
    sudo chown root:root "$dir"
done

for device in "${devices[@]}"; do
    if [ -b "$device" ]; then
        for dir in "${dirs[@]}"; do
            if ! mountpoint -q "$dir"; then
                sudo mount "$device" "$dir"
                break
            fi
        done
    fi
done
