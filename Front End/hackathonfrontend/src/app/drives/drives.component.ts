import {AfterViewInit, Component, OnInit} from '@angular/core';
import * as L from 'leaflet';
import 'leaflet-routing-machine'
import { icon, Marker } from 'leaflet';
import {latlong} from 'models/latlong';
import {Car} from '../../models/Car';
import {Router} from '@angular/router';
import {HttpClient} from '@angular/common/http';
import {AppService} from '../app.service';
import {MatSnackBar} from '@angular/material/snack-bar';
import {datapoint} from '../../models/datapoint';
import {element} from 'protractor';
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

@Component({
  selector: 'app-maps',
  templateUrl: './drives.component.html',
  styleUrls: ['./drives.component.css']
})
export class DrivesComponent implements OnInit {
    coords = new Array<datapoint>();
    routes = new Array<Array<datapoint>>();
    routeIds = new Array<number>();
    private map;
  private initMap(): void {
    this.map = L.map('map', {
      center: [51.8843034, 5.1871465],
      zoom: 7.5,
    });
    const tiles = L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
      maxZoom: 18,
      minZoom: 3,
      attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
    });
    tiles.addTo(this.map);
  }
  constructor(
      public router: Router,
      private http: HttpClient,
      private appService: AppService,
      private _snackBar: MatSnackBar,
  ) { }

  ngOnInit() {
    this.http.get<any>('https://localhost:7168/Data/getDataPointsForUser/' + localStorage.getItem('userID')).subscribe(
        (response) => {
          this.coords = (response) as datapoint[];
          for (const coord of this.coords) {
            if (!this.routeIds.includes(coord.routeId)) {
                this.routeIds.push(coord.routeId);
            }
          }
          for (const idroute of this.routeIds) {
              const route = this.coords.filter(x => x.routeId === idroute);
              this.routes.push(route);
          }
        });
    this.initMap();
  }
  changeMap(selectedCoords) {
      this.map.remove();
      this.initMap();
      L.Routing.control({
          show: false,
          plan: new L.Routing.Plan(
              // loop through data points and add them as waypoints
              // tslint:disable-next-line:no-shadowed-variable
              selectedCoords.map((element) => {
                  return L.latLng(element.lat_long.item1, element.lat_long.item2)
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
}
