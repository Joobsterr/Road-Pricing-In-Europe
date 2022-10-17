import { Routes } from '@angular/router';

import { DashboardComponent } from '../../dashboard/dashboard.component';
import { UserProfileComponent } from '../../user-profile/user-profile.component';
import { BillingComponent } from '../../billing/billing.component';
import { GarageComponent } from '../../garage/garage.component';
import { DrivesComponent } from '../../drives/drives.component';
import { RoadPricingComponent } from '../../road-pricing/road-pricing.component'
import { LoginComponent} from '../../login/login.component';
import {NotfoundComponent} from '../../notfound/notfound.component';
import {AuthGuard} from '../../auth.guard';

export const AdminLayoutRoutes: Routes = [
    { path: 'dashboard',      component: DashboardComponent, canActivate: [AuthGuard] },
    { path: 'user-profile',   component: UserProfileComponent, canActivate: [AuthGuard] },
    { path: 'billing',     component: BillingComponent, canActivate: [AuthGuard] },
    { path: 'garage',          component: GarageComponent, canActivate: [AuthGuard] },
    { path: 'drives',           component: DrivesComponent, canActivate: [AuthGuard] },
    { path: 'road-pricing',           component: RoadPricingComponent, canActivate: [AuthGuard] },
    { path: 'login', component: LoginComponent},
    { path: '**', redirectTo: '404'},
    { path: '404', component: NotfoundComponent}
];
