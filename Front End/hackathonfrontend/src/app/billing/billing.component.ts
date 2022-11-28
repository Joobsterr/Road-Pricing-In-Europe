import { Component, OnInit } from '@angular/core';
import { AppService } from 'app/app.service';
import { Bill } from 'models/Bill';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-table-list',
  templateUrl: './billing.component.html',
  styleUrls: ['./billing.component.css']
})
export class BillingComponent implements OnInit {
  userId: number;
  allBills: Array<Bill>;
  selectedModalBill: Bill = new Bill;

  constructor(
    private http: HttpClient
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
          var totalPrice = 0;
          dataBill.month = this.toMonthName(dataBill.month);
          dataBill.trips.forEach(trip => {
            totalPrice += trip.totalPrice;
          });
          dataBill.totalPrice = totalPrice;
        });

        this.allBills = data;
      },
      error: error => {
        console.log("Is the backend service on?")
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

}
