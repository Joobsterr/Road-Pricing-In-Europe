import { Component, OnInit, ɵclearResolutionOfComponentResourcesQueue } from '@angular/core';
import {Router} from "@angular/router"


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  username:string;
  password:string;
  constructor(public router:Router) { }

  ngOnInit(): void {
  }

  Login()
  {
    if(this.username=="admin" && this.password=="password")
    {
      //complete login.
      console.log("Login");
      this.router.navigate(['/dashboard']);

    }
    else
    {
      console.log("Login Failed");
    }
  }
}
