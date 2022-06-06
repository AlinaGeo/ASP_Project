import { Directive, HostListener } from '@angular/core';
import { MessageService } from './services/message.service';

@Directive({
  selector: '[appDir2]'
})
export class Dir2Directive {
  numberOfClicks = 0;

  constructor(private messageService: MessageService) { }

  @HostListener('click', ['$event.target']) onClick(btn : any) {
    console.log('button', btn, 'Number of wishes:', this.numberOfClicks++);
    this.messageService.add(`You made ${this.numberOfClicks} wishes!`);
  }
}
