import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AdministrationPricesDTO } from 'models/AdministrationPricesDTO';
import { map } from 'rxjs';

const highwayPrice=0;
const motorwayPrice=0;
const outsideCityLimits=0;
const withinCityLimints=0;

@Component({
  selector: 'app-road-pricing',
  templateUrl: './road-pricing.component.html',
  styleUrls: ['./road-pricing.component.css']
})


export class RoadPricingComponent implements OnInit {
  adminPrice:AdministrationPricesDTO[]=[];

  constructor(private http:HttpClient) { }
  value=0;
  highwayPrice=0;
  ngOnInit(): void {
    this.http.get<{[key:string]:AdministrationPricesDTO}>("https://localhost:7119/Administration").pipe(map((data)=>{

      const pricesAdmin=[];
      for(const key in data)
      {
        if(data.hasOwnProperty(key))
        {
          pricesAdmin.push({...data[key],id:key})
        }
      }
      console.log(pricesAdmin);
      return pricesAdmin
    })).subscribe((priceData)=>{
      console.log(priceData);
      this.adminPrice=priceData;
      console.log(this.adminPrice[0].carType);
      this.highwayPrice=this.adminPrice[0].price;
    })
  }
  

  ChangeHighWayPrice(value:any):void
  {
      console.log(value);
      const newPrice={id: 0,
      fuelType: "string",
      carType: "string",
      roadType: "string",
      timeframe: "2022-11-21T12:51:54.044Z",
      price: value};
      newPrice.price=value;
      
      this.http.put("https://localhost:7119/Administration/UpdatePrices/5",newPrice).subscribe((data)=>
      {
        console.log(data);
      })
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
