//
//  main.m
//  MortalKombatGame
//
//  Created by Antonio on 10/29/14.
//  Copyright (c) 2014 Antonio Marinov. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "Hero.h"
#import "Ninja.h"
#import "Sorcerer.h"
#import "Raiden.h"
#import "Scorpion.h"
#import "Paladin.h"


int main(int argc, const char * argv[]) {
    @autoreleasepool {
       // Hero *h = [[Hero alloc] initWithName:@"Gopeto" andLife:200 andPunch:123 andKick:23 andPower:34];
        
        Ninja *ninja = [[Ninja alloc] initWithName:@"Ninja" andLife: 300 andPunch:5 andKick:10 andPower:5];
        Sorcerer *sorc = [[Sorcerer alloc] initWithName:@"Sorc" andLife:10 andPunch:2 andKick:4 andPower:20];
        Raiden *raiden = [[Raiden alloc] initWithName:@"Raiden" andLife:30 andPunch:10 andKick:15 andPower:9];
        Paladin *paladin = [[Paladin alloc] initWithName:@"Paladin" andLife:10 andPunch:50 andKick:50 andPower:50];
        Scorpion *scorpion = [[Scorpion alloc] initWithName:@"Scorpion" andLife:100 andPunch:20 andKick:20 andPower:20];
        
        NSLog(@"BEFORE THE NINJA ATTACK TO THE SORC");
        NSLog(@"Sorc power -> %d Ninja power -> %d", sorc.power, ninja.power);
        [ninja castSpellOnEnemy: sorc];
        NSLog(@"Sorc power -> %d Ninja power -> %d", sorc.power, ninja.power);
        
        NSLog(@"BEFORE THE NINJA ATTACK TO THE SORC");
        NSLog(@"Sorc power -> %d Ninja power -> %d", sorc.power, ninja.power);
        [ninja castSpellOnEnemy: sorc];
        NSLog(@"Sorc power -> %d Ninja power -> %d", sorc.power, ninja.power);
        
        [paladin castSpellOnEnemy: sorc];
        
        [raiden kickEnemy: scorpion];
        
        [scorpion punchEnemy: paladin];
    }
    return 0;
}
