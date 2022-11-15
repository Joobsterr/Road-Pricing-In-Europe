import { Component, OnInit } from '@angular/core';
import {User} from '../../models/User';
import {Router} from '@angular/router';
import {HttpClient} from '@angular/common/http';
import {AppService} from '../app.service';
import {MatSnackBar} from '@angular/material/snack-bar';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {

  nUser: User;
  constructor(
      public router: Router,
      private http: HttpClient,
      private appService: AppService,
      private _snackBar: MatSnackBar,
  ) { }

  ngOnInit() {
    this.appService.getUsersByID(localStorage.getItem('userID')).subscribe({
      next: (response) => {
        this.nUser = response as User;
        console.log(this.nUser);
      },
      error: (error) => {
        this._snackBar.open('Oops, something went wrong!', null, {duration: 5000})
      }
    });
  }
  reload() {
    window.location.reload();
  }
}
