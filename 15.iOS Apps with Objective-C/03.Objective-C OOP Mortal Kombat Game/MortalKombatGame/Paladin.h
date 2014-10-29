//
//  Paladin.h
//  MortalKombatGame
//
//  Created by Antonio on 10/29/14.
//  Copyright (c) 2014 Antonio Marinov. All rights reserved.
//

#import "Hero.h"

@interface Paladin : Hero
@property (nonatomic, strong) NSString* spell;
@property int paladinDamage;

-(instancetype) initWithName:(NSString *)name andLife: (int) life andPunch: (int) punch andKick: (int) kick andPower: (int) power;

@end
