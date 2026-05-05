import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-button-component',
  imports: [CommonModule],
  templateUrl: './button-component.html',
  styleUrl: './button-component.css',
})
export class ButtonComponent {
  @Input() label: string = 'Click me';
  @Input() variant: 'primary' | 'secondary' | 'danger'  = 'primary';
  @Input() type: 'button' | 'submit' = 'button';

  @Output() btnClick = new EventEmitter<void>();

  onClick(){
    this.btnClick.emit()
  }


}
