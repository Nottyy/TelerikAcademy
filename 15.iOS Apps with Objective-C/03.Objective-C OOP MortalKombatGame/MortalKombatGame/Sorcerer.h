//
//  Sorcerer.h
//  MortalKombatGame
//
//  Created by Antonio on 10/29/14.
//  Copyright (c) 2014 Antonio Marinov. All rights reserved.
//

#import "Hero.h"

@interface Sorcerer : Hero

@property (nonatomic, strong) NSString* spell;
@property int sorcDamage;

//-(instancetype) initWithName:(NSString *)name andLife: (NSNumber *) life andPunch: (NSNumber *) punch andKick: (NSNumber *) kick andPower: (NSNumber *) power;
@end
