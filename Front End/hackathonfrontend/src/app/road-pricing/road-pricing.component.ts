import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';


let highwayPrice=0;
let motorwayPrice=0;
let outsideCityLimits=0
let withinCityLimints=0;

@Component({
  selector: 'app-road-pricing',
  templateUrl: './road-pricing.component.html',
  styleUrls: ['./road-pricing.component.css']
})


export class RoadPricingComponent implements OnInit {

  constructor(private http:HttpClient) { }

  ngOnInit(): void {
  }


  ChangeHighWayPrice():void
  {

  }
  ChangeMotorWayPrice():void
  {

  }

  ChangeOutsideCityLimitsPrice():void
  {

  }
  ChangeWithinCityLimints():void
  {

  }

}
