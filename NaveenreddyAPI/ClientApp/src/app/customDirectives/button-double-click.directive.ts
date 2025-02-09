import { Directive, ElementRef, HostListener, Input, OnDestroy, OnInit, Output } from '@angular/core';

@Directive({
  selector: '[appButtonDoubleClick]'
})
export class ButtonDoubleClickDirective {

  @Input() appButtonDisable: number;
  private button: HTMLButtonElement;

  constructor(private elementRef: ElementRef) {
    this.button = this.elementRef.nativeElement;
  }
  
  @HostListener('click', ['$event'])
  clickEvent() {
    this.button.disabled = true;
    setTimeout(() => {
      this.button.disabled = false;
    }, this.appButtonDisable);
  }
}
