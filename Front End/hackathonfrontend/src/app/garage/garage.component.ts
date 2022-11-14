import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';
import {HttpClient} from '@angular/common/http';
import {AppService} from '../app.service';
import {MatSnackBar} from '@angular/material/snack-bar';

@Component({
  selector: 'app-icons',
  templateUrl: './garage.component.html',
  styleUrls: ['./garage.component.css']
})
export class GarageComponent implements OnInit {
  licenseplate: string;
  userID: number;

  constructor(
      public router: Router,
      private http: HttpClient,
      private appService: AppService,
      private _snackBar: MatSnackBar
  ) { }
  ngOnInit() {}
  addNewCar() {
    if (this.licenseplate == null || this.licenseplate.length === 0) {
      this._snackBar.open('Licenseplate is invalid', null, {duration: 5000})
    } else {
      this.userID = +localStorage.getItem('userID');
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
}
