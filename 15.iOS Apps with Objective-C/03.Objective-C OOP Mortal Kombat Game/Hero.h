//
//  Hero.h
//  MortalKombatGame
//
//  Created by Antonio on 10/29/14.
//  Copyright (c) 2014 Antonio Marinov. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "IFighting.h"

@interface Hero : NSObject<IFighting>

@property int life;
@property (nonatomic, strong) NSString *name;
@property int kickDamage;
@property int punchDamage;
@property int skillDamage;
@property int skillPower;


-(instancetype) initWithName:(NSString *)name andLife: (int) life andPunch: (int) punch andKick: (int) kick andPower: (int) power;
@end
