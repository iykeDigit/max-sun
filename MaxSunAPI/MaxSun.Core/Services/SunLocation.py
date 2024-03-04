import os
import ephem
import datetime
import geocoder
import asyncio

def sunLocation():
    location = geocoder.ip('me')
    obs = ephem.Observer()
    obs.lat = location.latlng[0]
    obs.lon = location.latlng[1]
    obs.elevation = 0
    obs.date = datetime.datetime.now()
    sun = ephem.Sun()
    sun.compute(obs)
    return f"{sun.alt}, {sun.az}"