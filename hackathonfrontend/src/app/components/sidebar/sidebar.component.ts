import { Component, OnInit } from '@angular/core';

declare const $: any;
declare interface RouteInfo {
    path: string;
    title: string;
    icon: string;
    class: string;
}
export const ROUTES: RouteInfo[] = [
    { path: '/dashboard', title: 'Dashboard',  icon: 'dashboard', class: '' },
    { path: '/drives', title: 'Drives',  icon:'location_on', class: '' },
    { path: '/garage', title: 'My Garage',  icon:'bubble_chart', class: '' },
    { path: '/billing', title: 'Billing',  icon:'content_paste', class: '' },
    { path: '/road-pricing', title: 'Road Pricing',  icon:'content_paste', class: '' },
];

export const TITLEROUTES: RouteInfo[] = [
  { path: '/dashboard', title: 'Dashboard',  icon: 'dashboard', class: '' },
  { path: '/drives', title: 'Drives',  icon:'location_on', class: '' },
  { path: '/garage', title: 'My Garage',  icon:'bubble_chart', class: '' },
  { path: '/billing', title: 'Billing',  icon:'content_paste', class: '' },
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

  constructor() { }

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
