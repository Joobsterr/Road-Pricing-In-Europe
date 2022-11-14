import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';
import {HttpClient} from '@angular/common/http';
import {AppService} from '../app.service';
import {MatSnackBar} from '@angular/material/snack-bar';
import {Car} from '../../models/Car';
import next from 'ajv/dist/vocabularies/next';

@Component({
  selector: 'app-icons',
  templateUrl: './garage.component.html',
  styleUrls: ['./garage.component.css']
})
export class GarageComponent implements OnInit {
  licenseplate: string;
  userID: number;
  AllCars: Array<Car>;

  constructor(
      public router: Router,
      private http: HttpClient,
      private appService: AppService,
      private _snackBar: MatSnackBar,
  ) { }
  ngOnInit(): void {
    this.userID = +localStorage.getItem('userID');
    this.getCars();
  }
  addNewCar() {
    if (this.licenseplate == null || this.licenseplate.length === 0 || this.licenseplate.length > 6) {
      this._snackBar.open('License plate is invalid', null, {duration: 5000})
    } else {
      this.appService.addNewCar(this.licenseplate, this.userID).subscribe({
        next: (response) => {
          window.location.reload();
        },
        error: (error) => {
          this._snackBar.open('Oops, something went wrong!', null, {duration: 5000})
        }
      });
    }
  }
  getCars() {
    this.appService.getCarsByUser(this.userID.toString()).subscribe(
        (response) => {
          this.AllCars = (response) as Car[];
          this.AllCars.forEach(x => x.purchaseDate = new Date(x.purchaseDate))
        });
  }
}
