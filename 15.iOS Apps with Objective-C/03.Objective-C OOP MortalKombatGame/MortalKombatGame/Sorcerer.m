//
//  Sorcerer.m
//  MortalKombatGame
//
//  Created by Antonio on 10/29/14.
//  Copyright (c) 2014 Antonio Marinov. All rights reserved.
//

#import "Sorcerer.h"

@implementation Sorcerer

const int SORCERER_POWER = 4;

-(instancetype)initWithName:(NSString *)name andLife:(int)life andPunch:(int)punch andKick:(int)kick andPower:(int)power{
    
    if (self = [super initWithName:name andLife:life andPunch:punch andKick:kick andPower:power]) {
        self.spell = @"FREEZE";
        self.sorcDamage = (self.kickDamage + self.punchDamage) / 2;
    }
    
    return self;
}

-(void)castSpellOnEnemy:(Hero*)enemy{
    if (enemy.life <= 0) {
        NSLog(@"%@ can not attack %@. He is already dead!",self.name, enemy.name);
    }
    else{
        enemy.life = enemy.life - self.sorcDamage;
        
        self.power = self.power + SORCERER_POWER;
        enemy.power = enemy.power - SORCERER_POWER;
        
        if (enemy.life <= 0) {
            NSLog(@"%@ killed %@!", self.name, enemy.name);
        }
        else{
            NSLog(@"%@ attacked %@ with damage %d and casted spell %@. %@ health left -> %d", self.name, enemy.name, self.sorcDamage, self.spell, enemy.name, enemy.life);
        }
    }
}
@end
