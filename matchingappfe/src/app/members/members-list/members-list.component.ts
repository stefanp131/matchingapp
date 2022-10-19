import { Component, OnInit } from '@angular/core';
import { Member } from 'src/app/_models/member';
import { MembersService } from 'src/app/_services/members.service';

@Component({
  selector: 'app-members-list',
  templateUrl: './members-list.component.html',
  styleUrls: ['./members-list.component.scss']
})
export class MembersListComponent implements OnInit {
  membersList: Member[];
  constructor(private membersService: MembersService) { }

  ngOnInit(): void {
    this.initMembersList();
  }

  initMembersList() {
    this.membersService.getMembers().subscribe(data => {
      this.membersList = data;
    })
  }
}
