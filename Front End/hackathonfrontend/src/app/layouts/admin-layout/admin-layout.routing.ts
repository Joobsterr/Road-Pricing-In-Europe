import { Routes } from '@angular/router';

import { DashboardComponent } from '../../dashboard/dashboard.component';
import { UserProfileComponent } from '../../user-profile/user-profile.component';
import { BillingComponent } from '../../billing/billing.component';
import { GarageComponent } from '../../garage/garage.component';
import { DrivesComponent } from '../../drives/drives.component';
import { RoadPricingComponent } from '../../road-pricing/road-pricing.component'
import { LoginComponent} from '../../login/login.component';
import {NotfoundComponent} from '../../notfound/notfound.component';

export const AdminLayoutRoutes: Routes = [
    { path: 'dashboard',      component: DashboardComponent },
    { path: 'user-profile',   component: UserProfileComponent },
    { path: 'billing',     component: BillingComponent },
    { path: 'garage',          component: GarageComponent },
    { path: 'drives',           component: DrivesComponent },
    { path: 'road-pricing',           component: RoadPricingComponent },
    { path: 'login', component: LoginComponent },
    { path: '**', redirectTo: '404'},
    { path: '404', component: NotfoundComponent}
];
