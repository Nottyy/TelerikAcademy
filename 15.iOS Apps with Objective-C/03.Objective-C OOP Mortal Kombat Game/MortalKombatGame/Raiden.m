//
//  Raiden.m
//  MortalKombatGame
//
//  Created by Antonio on 10/29/14.
//  Copyright (c) 2014 Antonio Marinov. All rights reserved.
//

#import "Raiden.h"

@implementation Raiden
const int RAIDEN_POWER = 430;

-(instancetype)initWithName:(NSString *)name andLife:(int)life andPunch:(int)punch andKick:(int)kick andPower:(int)power{
    
    if (self = [super initWithName:name andLife:life andPunch:punch andKick:kick andPower:power]) {
        self.spell = @"LIGHTNING ATTACK";
        self.raidenDamage = (self.kickDamage + self.punchDamage) / 2;
    }
    
    return self;
}

-(void)castSpellOnEnemy:(Hero*)enemy{
    if (enemy.life <= 0) {
        NSLog(@"%@ can not attack %@. He is already dead!",self.name, enemy.name);
    }
    else{
        enemy.life = enemy.life - self.raidenDamage;
        
        self.power = self.power + RAIDEN_POWER;
        enemy.power = enemy.power - RAIDEN_POWER;
        
        if (enemy.life <= 0) {
            NSLog(@"%@ killed %@!", self.name, enemy.name);
        }
        else{
            NSLog(@"%@ attacked %@ with damage %d and casted spell %@. %@ health left -> %d", self.name, enemy.name, self.raidenDamage, self.spell, enemy.name, enemy.life);
        }
    }
}

@end
