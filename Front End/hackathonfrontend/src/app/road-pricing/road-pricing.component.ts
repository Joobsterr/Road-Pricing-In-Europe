import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AdministrationPricesDTO } from 'models/AdministrationPricesDTO';
import { map } from 'rxjs';


@Component({
  selector: 'app-road-pricing',
  templateUrl: './road-pricing.component.html',
  styleUrls: ['./road-pricing.component.css']
})


export class RoadPricingComponent implements OnInit {
  adminPrice: AdministrationPricesDTO[] = [];
  value = 0;
  highwayPrice = 0;
  MotorwayPrice = 0;
  outsideCityLimits = 0;
  withinCityLimints = 0;
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get<{[key: string]: AdministrationPricesDTO}>('https://localhost:7119/Administration').pipe(map((data) => {

      const pricesAdmin = [];
      for (const key in data) {
        if (data.hasOwnProperty(key)) {
          pricesAdmin.push({...data[key], id: key})
        }
      }
      return pricesAdmin
    })).subscribe((priceData) => {
      this.adminPrice = priceData;
      this.highwayPrice = this.adminPrice[0].price;
      this.MotorwayPrice = this.adminPrice[1].price;
      this.outsideCityLimits = this.adminPrice[2].price;
      this.withinCityLimints = this.adminPrice[3].price;
    })
  }


  ChangeHighWayPrice(): void {

      const newPrice = {id: 0,
      fuelType: 'string',
      carType: 'string',
      roadType: 'string',
      timeframe: '2022-11-21T12:51:54.044Z',
      price: this.highwayPrice};
      this.http.put('https://localhost:7119/Administration/UpdatePrices/5', newPrice).subscribe();
  }
  ChangeMotorWayPrice(): void {

    const newPrice = {id: 0,
    fuelType: 'string',
    carType: 'string',
    roadType: 'string',
    timeframe: '2022-11-21T12:51:54.044Z',
    price: this.MotorwayPrice};
    this.http.put('https://localhost:7119/Administration/UpdatePrices/6', newPrice).subscribe();
  }

  ChangeOutsideCityLimitsPrice(): void {

    const newPrice = {id: 0,
    fuelType: 'string',
    carType: 'string',
    roadType: 'string',
    timeframe: '2022-11-21T12:51:54.044Z',
    price: this.outsideCityLimits};
    this.http.put('https://localhost:7119/Administration/UpdatePrices/7', newPrice).subscribe();
  }
  ChangeWithinCityLimints(): void {

    const newPrice = {id: 0,
    fuelType: 'string',
    carType: 'string',
    roadType: 'string',
    timeframe: '2022-11-21T12:51:54.044Z',
    price: this.withinCityLimints};
    this.http.put('https://localhost:7119/Administration/UpdatePrices/8', newPrice).subscribe();
  }
}
