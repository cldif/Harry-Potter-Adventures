// IMPORTS FOR THE ROUTES

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GameComponent } from './game/game.component';
import { SettingsComponent } from './settings/settings.component';
import { AdminComponent } from './admin/admin.component';
import { HealthComponent } from './health/health.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';

// ROUTE LIST
export const routes: Routes = [
  { 
    path: 'game', 
    component: GameComponent 
  },
  { 
    path: 'settings', 
    component: SettingsComponent 
  },
  { 
    path: 'admin', 
    component: AdminComponent 
  },
  { 
    path: 'health', 
    component: HealthComponent 
  },
  {
    path: '**',
    component: PageNotFoundComponent
  }
];

// MODULES
@NgModule({
  imports: [
    RouterModule.forRoot(routes) 
  ],
  exports: [
    RouterModule
  ]
})

// EXPORT THE CLASS
export class AppRoutingModule { 
}