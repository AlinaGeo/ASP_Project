import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RestaurantChildComponent } from './restaurant-child.component';

describe('RestaurantChildComponent', () => {
  let component: RestaurantChildComponent;
  let fixture: ComponentFixture<RestaurantChildComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RestaurantChildComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RestaurantChildComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
