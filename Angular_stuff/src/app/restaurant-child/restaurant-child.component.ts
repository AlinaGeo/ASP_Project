import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { MessageService } from '../services/message.service';

@Component({
  selector: 'app-restaurant-child',
  templateUrl: './restaurant-child.component.html',
  styleUrls: ['./restaurant-child.component.css']
})
export class RestaurantChildComponent implements OnInit {

  @Input() messageFromParent: any;
  @Output() messageFromChild = new EventEmitter<string>();

  constructor(private messageService: MessageService) { }

  ngOnInit(): void {
    console.log(this.messageFromParent);
  }

  public wish(): void {
    this.messageService.add('You wished for free food!');
    this.messageFromChild.emit('You wished for free food!');
  }

}
