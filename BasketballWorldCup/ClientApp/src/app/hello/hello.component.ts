import { Component, HostListener } from "@angular/core";
import { Router } from "@angular/router";


export enum KEY_CODE {
  ENTER = 13
}

@Component({
    selector: "hello",
    templateUrl: "./hello.component.html"
})
export class HelloComponent {
  constructor(
    private readonly router: Router) { }

  @HostListener("window:keyup", ["$event"])
  keyEvent(event: KeyboardEvent) {
    if (event.keyCode === KEY_CODE.ENTER) {
      this.goToFirstRound();
    }
  }

  goToFirstRound() {
    this.router.navigate(["/instruction"]);
  }
}
