import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import {UserBody} from '../models/UserBody';
@Injectable({
  providedIn: 'root'
})
export class AppService {

   rootUrl = '/api';

  constructor(private http: HttpClient) { }
  getUsers() {
    return this.http.get( this.rootUrl + '/User/getUsers');
  }
  login(nUser: UserBody) {
    return this.http.post(this.rootUrl + '/User/login', JSON.stringify(nUser));
  }
}
