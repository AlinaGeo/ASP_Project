import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RestaurantsComponent } from 'src/app/modules/restaurants/restaurants/restaurants.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'restaurants',
  },
  {
    path: 'restaurants',
    component: RestaurantsComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RestaurantsRoutingModule { }
