import { Component, OnInit } from '@angular/core';
import { AppService } from 'app/app.service';
import { Bill } from 'models/Bill';
import { HttpClient } from '@angular/common/http';
import {Router} from '@angular/router';
import {MatSnackBar} from '@angular/material/snack-bar';
import {data} from 'jquery';
import priceLink from '../../models/priceLink';
import PriceLink from '../../models/priceLink';

@Component({
  selector: 'app-table-list',
  templateUrl: './billing.component.html',
  styleUrls: ['./billing.component.css']
})
export class BillingComponent implements OnInit {
  userId: number;
  allBills: Array<Bill>;
  selectedModalBill: Bill = new Bill;
  pLink: priceLink = new priceLink;

  constructor(
      public router: Router,
      private http: HttpClient,
      private appService: AppService,
      private _snackBar: MatSnackBar
  ) { }

  ngOnInit() {
    this.userId = +localStorage.getItem('userID');
    this.getBills();
  }

  getBills() {
    // this.appService.getBillsByUser(this.userID.toString()).subscribe(
    //   (response) => {
    //     console.log(response);
    //     // this.allBills = (response) as Bill[];
    //   }
    // );

    this.http.get<any>('https://localhost:7120/Bill/getUserBills/' + this.userId).subscribe({
      next: data => {
        data.forEach(dataBill => {
          let totalPrice = 0;
          dataBill.month = this.toMonthName(dataBill.month);
          dataBill.trips.forEach(trip => {
            totalPrice += trip.totalPrice;
          });
          dataBill.totalPrice = totalPrice;
        });

        this.allBills = data;
      },
      error: error => {
        console.log('Is the backend service on?')
        console.log(error)
      }
    })
  }

  toMonthName(monthNumber) {
    const date = new Date();
    date.setMonth(monthNumber - 1);

    return date.toLocaleString('en-US', {
      month: 'long',
    });
  }

  onModalClick(bill) {
    this.selectedModalBill = bill;
  }
  paymentBill(billId: string) {
    this.http.get<any>('https://localhost:7120/Bill/getPaymentLink/' + localStorage.getItem('userID').toString() + '/' + billId.toString()).subscribe({
      next: (response) => {
        this.pLink = (response) as priceLink
        window.open(this.pLink.paymentLink, '_blank').focus();
      },
      error: (error) => {
        this._snackBar.open('Something went wrong!', null, {duration: 5000})
      }
    });
  }
}
