import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RestaurantsRoutingModule } from './restaurants-routing.module';
import { MatButtonModule } from '@angular/material/button';
import { MaterialModule } from '../material/material.module';
import { MarksPipe } from 'src/app/marks.pipe';

@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    RestaurantsRoutingModule,
    MatButtonModule,
    MaterialModule,
  ],
  exports: [
  ]
})
export class RestaurantsModule { }
