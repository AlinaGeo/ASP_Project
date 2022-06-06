import { Component, OnInit } from '@angular/core';
import { LocationsService } from 'src/app/services/locations.service';
import { Location } from 'src/app/interfaces/location';
import { MessageService } from 'src/app/services/message.service';

@Component({
  selector: 'app-locations',
  templateUrl: './locations.component.html',
  styleUrls: ['./locations.component.css']
})
export class LocationsComponent implements OnInit {
  public locations : Location[] = [];
  public test = 'test';

  constructor(
    private locationsService: LocationsService,
    private messageService: MessageService,
  ) { }

  ngOnInit(): void {
    this.locationsService.getLocations().subscribe(
      (result: Location[]) => {
        // console.log(result);
        this.locations = result;
        console.log(this.locations);
        for (let i = 0; i < this.locations.length; i++) {
          // this.messageService.add(`${this.locations[i].Street}`);
        }
      },
      (error) => {
        console.error(error);
      }
    );
  }

}
