import { Component, OnInit, ɵclearResolutionOfComponentResourcesQueue } from '@angular/core';
import {Router} from '@angular/router';
import * as shajs from 'sha.js';
import {HttpClient} from '@angular/common/http';
import {AppService} from '../app.service';
import {UserDTO} from '../../models/UserDTO';
import {MatSnackBar} from '@angular/material/snack-bar';
import {duration} from 'moment';
import {RegisterDTO} from '../../models/RegisterDTO';
import {empty} from 'rxjs';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  username: string;
  password: string;
  rUsername: string;
  rPassword: string;
  BSN: number;
  nPassword: string;

  constructor(
      public router: Router,
      private http: HttpClient,
      private appService: AppService,
      private _snackBar: MatSnackBar) {
  }

  ngOnInit(): void {
  }

  Login() {
    const nUser = new UserDTO();
    nUser.userName = this.username;
    if (this.username == null || this.username.length === 0 || this.password == null || this.password.length === 0) {
      this._snackBar.open('Username or Password entered incorrectly', null, {duration: 5000,})
    } else {
      nUser.passWord = shajs('sha256').update(this.password).digest('hex');

      this.appService.login(nUser).subscribe({
        next: (response) => {
          this.router.navigateByUrl('/dashboard');
          localStorage.setItem('userID', response.toString());
        },
        error: (error) => {
          this._snackBar.open('Credentials are incorrect', null, {duration: 5000})
        }
      });
    }
  }
  Register() {
    const nRegister = new RegisterDTO();
    nRegister.BSN = this.BSN;
    nRegister.userName = this.rUsername;
    if (this.rUsername == null || this.rUsername.length === 0 || this.rPassword == null || this.rPassword.length === 0) {
      this._snackBar.open('Incorrect details entered', null, {duration: 5000,})
    } else {
      nRegister.passWord = shajs('sha256').update(this.rPassword).digest('hex');
      this.appService.register(nRegister).subscribe({
        next: (response) => {
          window.location.reload();
        },
        error: (error) => {
          this._snackBar.open('One of the entered details is incorrect', null, {duration: 5000,})
        }
      });
    }
  }
}
