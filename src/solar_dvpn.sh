#!/bin/bash

api="https://api.dvpn.solar/api"
user_agent="okhttp/4.7.2"

function get_device_token() {
	response=$(curl --request POST \
		--url "$api/device" \
		--user-agent "$user_agent" \
		--header "content-type: application/json" \
		--data '{"platform": "ANDROID"}')
	if [ -n $(jq -r ".deviceToken" <<< "$response") ]; then
		device_token=$(jq -r ".deviceToken" <<< "$response")
	fi
	echo $response
}

function get_own_ip() {
	curl --request GET \
		--url "$api/vpn/ip" \
		--user-agent "$user_agent" \
		--header "content-type: application/json"
}

function get_countries() {
	curl --request GET \
		--url "$api/vpn/countries" \
		--user-agent "$user_agent" \
		--header "content-type: application/json" \
		--header "x-device-token: $device_token"
}

function get_servers() {
	curl --request GET \
		--url "$api/vpn/servers" \
		--user-agent "$user_agent" \
		--header "content-type: application/json" \
		--header "x-device-token: $device_token"
}
