import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

declare const $: any;
declare interface RouteInfo {
    path: string;
    title: string;
    icon: string;
    class: string;
}
export const ROUTES: RouteInfo[] = [
    { path: '/dashboard', title: 'Dashboard',  icon: 'dashboard', class: '' },
    { path: '/drives', title: 'Drives',  icon:'map', class: '' },
    { path: '/garage', title: 'My Garage',  icon:'directions_car', class: '' },
    { path: '/billing', title: 'Billing',  icon:'currency_exchange', class: '' },
    { path: '/road-pricing', title: 'Road Pricing',  icon:'content_paste', class: '' },
];

export const TITLEROUTES: RouteInfo[] = [
  { path: '/dashboard', title: 'Dashboard',  icon: 'dashboard', class: '' },
  { path: '/drives', title: 'Drives',  icon:'map', class: '' },
  { path: '/garage', title: 'My Garage',  icon:'directions_car', class: '' },
  { path: '/billing', title: 'Billing',  icon:'currency_exchange', class: '' },
  { path: '/user-profile', title: 'User Profile',  icon:'content_paste', class: '' },
  { path: '/road-pricing', title: 'Road Pricing',  icon:'content_paste', class: '' },
];

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {
  menuItems: any[];

  constructor( public router: Router ) { }

  ngOnInit() {
    this.menuItems = ROUTES.filter(menuItem => menuItem);
  }
  isMobileMenu() {
      if ($(window).width() > 991) {
          return false;
      }
      return true;
  };
}
