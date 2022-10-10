import { Component, OnInit, ɵclearResolutionOfComponentResourcesQueue } from '@angular/core';
import {Router} from '@angular/router';
import * as shajs from 'sha.js';
import {HttpClient} from '@angular/common/http';
import {AppService} from '../app.service';
import {UserBody} from '../../models/UserBody';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  username: string;
  password: string;
  nPassword: string;

  constructor(public router: Router, private http: HttpClient, private appService: AppService) {
  }

  ngOnInit(): void {
  }

  Login() {
    const nUser = new UserBody();
    nUser.userName = this.username;
    nUser.passWord = shajs('sha256').update(this.password).digest('hex');
    this.appService.login(nUser);
    console.log(nUser);
  }
}
