import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './auth.guard';
import { DashboardComponent } from './dashboard/dashboard.component';
import { RestaurantDetailComponent } from './restaurant-detail/restaurant-detail.component';
import { RestaurantsComponent } from './modules/restaurants/restaurants/restaurants.component';
import { LocationsComponent } from './modules/locations/locations.component';
import { DishesComponent } from './modules/dishes/dishes.component';
import { RestaurantFormComponent } from './modules/restaurant-form/restaurant-form.component';
import { DishFormComponent } from './modules/dish-form/dish-form.component';

const routes: Routes = [
  {
    path: '',
    canActivate: [AuthGuard],
    children: [
      {
        path: '',
        loadChildren: () => import('src/app/modules/restaurants/restaurants.module').then(m => m.RestaurantsModule),
      },
      {
        path: '',
        loadChildren: () => import('src/app/modules/dashboard/dashboard.module').then(m => m.DashboardModule),
      },
      {
        path: '',
        loadChildren: () => import('src/app/modules/locations/locations.module').then(m => m.LocationsModule),
      },
      {
        path: '',
        loadChildren: () => import('src/app/modules/dishes/dishes.module').then(m => m.DishesModule),
      }
    ]
  },

  {
    path: 'login',
    loadChildren: () => import('src/app/modules/auth/auth.module').then(m => m.AuthModule),
  },

  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },    // in cazul in care path-ul e gol, vreau sa fiu redirectionat catre dashboard
  { path: 'restaurants', component: RestaurantsComponent },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'locations', component: LocationsComponent},
  { path: 'dishes', component: DishesComponent},
  { path: 'restaurant-form', component: RestaurantFormComponent},
  { path: 'dish-form', component: DishFormComponent},
  { path: 'detail/:id', component: RestaurantDetailComponent },    // id dinamic
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
