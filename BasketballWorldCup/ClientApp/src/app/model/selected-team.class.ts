import { Team } from "./team.interface";

export class SelectedTeam {
  private selected: boolean;

  constructor(public readonly data: Team) {
    this.unselect();
  }

  isSelected(): boolean {
    return this.selected;
  }

  select() {
    this.selected = true;
  }

  unselect() {
    this.selected = false;
  }
}
