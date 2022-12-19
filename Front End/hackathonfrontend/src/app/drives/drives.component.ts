import {AfterViewInit, Component, OnInit} from '@angular/core';
import * as L from 'leaflet';
import 'leaflet-routing-machine'
import { icon, Marker } from 'leaflet';
import { Coords } from 'models/Coords';
const iconRetinaUrl = 'assets/img/marker-icon-2x.png';
const iconUrl = 'assets/img/marker-icon.png';
const shadowUrl = 'assets/img/marker-shadow.png';
const iconDefault = icon({
  iconRetinaUrl,
  iconUrl,
  shadowUrl,
  iconSize: [25, 41],
  iconAnchor: [12, 41],
  popupAnchor: [1, -34],
  tooltipAnchor: [16, -28],
  shadowSize: [41, 41]
});
Marker.prototype.options.icon = iconDefault;

const c1 = new Coords(51.4508647, 5.4509124);
const c2 = new Coords(51.443867, 5.45591);
const c3 = new Coords(51.442804, 5.4648277);

const coords = new Array<Coords>();
coords.push(c1, c2, c3);

@Component({
  selector: 'app-maps',
  templateUrl: './drives.component.html',
  styleUrls: ['./drives.component.css']
})
export class DrivesComponent implements AfterViewInit {
  private map;

  private initMap(): void {
    this.map = L.map('map', {
      center: [51.4381919, 5.4797248],
      zoom: 13
    });

    const tiles = L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
      maxZoom: 18,
      minZoom: 3,
      attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
    });
    tiles.addTo(this.map);
    L.Routing.control({
      plan: new L.Routing.Plan(
          // loop through data points and add them as waypoints
          coords.map((element) => {
            return L.latLng(element.lat, element.long)
          }), {
        createMarker: function (i, waypoint, n) {
          if (i === 0 || i === n - 1) {
            // show markers
            return L.marker(waypoint.latLng);
          }
          return false;
        }
      })
    }).addTo(this.map);
  }
  constructor() { }

  ngAfterViewInit(): void {
    this.initMap();
  }
}
