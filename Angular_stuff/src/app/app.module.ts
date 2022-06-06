import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RestaurantsComponent } from './modules/restaurants/restaurants/restaurants.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RestaurantDetailComponent } from './restaurant-detail/restaurant-detail.component';
import { MessagesComponent } from './messages/messages.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HttpClientModule } from '@angular/common/http';
import { LoginComponent } from './modules/auth/login/login.component';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { RestaurantChildComponent } from './restaurant-child/restaurant-child.component';
import { LocationsComponent } from './modules/locations/locations.component';
import { MarksPipe } from './marks.pipe';
import { HoverBtnDirective } from './hover-btn.directive';
import { Dir2Directive } from './dir2.directive';
import { DishesComponent } from './modules/dishes/dishes.component';
import { RestaurantFormComponent } from './modules/restaurant-form/restaurant-form.component';
import { DishFormComponent } from './modules/dish-form/dish-form.component';

// tot ce e declarat si folosit trebuie pus si in app.module.ts

@NgModule({
  declarations: [
    AppComponent,
    RestaurantsComponent,
    RestaurantDetailComponent,
    MessagesComponent,
    DashboardComponent,
    RestaurantChildComponent,
    LocationsComponent,
    MarksPipe,
    HoverBtnDirective,
    Dir2Directive,
    DishesComponent,
    RestaurantFormComponent,
    DishFormComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    NoopAnimationsModule,
    ReactiveFormsModule,
  ],
  exports: [
    MarksPipe,
    Dir2Directive,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
