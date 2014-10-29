//
//  Scorpion.h
//  MortalKombatGame
//
//  Created by Antonio on 10/29/14.
//  Copyright (c) 2014 Antonio Marinov. All rights reserved.
//

#import "Hero.h"

@interface Scorpion : Hero

@property (nonatomic, strong) NSString* spell;
@property int scorpionDamage;

-(instancetype) initWithName:(NSString *)name andLife: (int) life andPunch: (int) punch andKick: (int) kick andPower: (int) power;

@end
