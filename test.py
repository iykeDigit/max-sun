import os
import ephem
import datetime
import geocoder
import asyncio
import requests
import math


def sunLocation():
    location = geocoder.ip('me')
    obs = ephem.Observer()
    obs.lat = location.latlng[0]
    obs.lon = location.latlng[1]
    obs.elevation = get_elevation(obs.lat, obs.lon)
    obs.date = datetime.datetime.now()
    sun = ephem.Sun()
    sun.compute(obs)
    return f"{sun.alt}, {sun.az}"


def get_elevation(latitude, longitude):
    url = f"https://api.open-elevation.com/api/v1/lookup?locations={
        latitude},{longitude}"
    response = requests.get(url)
    data = response.json()
    if 'results' in data and len(data['results']) > 0:
        elevation = data['results'][0]['elevation']
        # Calculate angle of elevation assuming the distance to the sun (approximately 1 astronomical unit)
        # angle_of_elevation_degrees = math.degrees(math.atan(elevation_meters / distance_to_sun))
        distance_to_sun = 1.496e11  # meters (1 AU)
        angle_of_elevation_degrees = math.degrees(
            math.atan(elevation / distance_to_sun))
        # Convert angle to radians for use with ephem
        angle_of_elevation_radians = math.radians(angle_of_elevation_degrees)
        return angle_of_elevation_radians
    else:
        return None
