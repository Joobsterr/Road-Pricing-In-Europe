import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app.routing';
import { ComponentsModule } from './components/components.module';
import { AppComponent } from './app.component';
import { AdminLayoutComponent } from './layouts/admin-layout/admin-layout.component';
import { RoadPricingComponent } from './road-pricing/road-pricing.component';
import { NotfoundComponent } from './notfound/notfound.component';
import { LoginComponent } from './login/login.component';
import {MatSnackBarModule} from '@angular/material/snack-bar';

@NgModule({
  imports: [
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    ComponentsModule,
    RouterModule,
    AppRoutingModule,
      MatSnackBarModule,
  ],
  declarations: [
    AppComponent,
    AdminLayoutComponent,
    RoadPricingComponent,
    NotfoundComponent,
    LoginComponent,

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
