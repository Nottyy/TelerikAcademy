//
//  Hero.m
//  MortalKombatGame
//
//  Created by Antonio on 10/29/14.
//  Copyright (c) 2014 Antonio Marinov. All rights reserved.
//

#import "Hero.h"

@implementation Hero

const int PUNCH_POWER = 1;
const int KICK_POWER = 2;

@synthesize power;

-(instancetype) initWithName:(NSString *)name andLife: (int) life andPunch: (int) punch andKick: (int) kick andPower: (int) power{
    self = [super init];
    
    if (self) {
        self.name = name;
        self.life = life;
        self.power = power;
        self.kickDamage = kick;
        self.punchDamage = punch;
    }
    
    return self;
}

-(void) punchEnemy: (Hero*) enemy{
    if (enemy.life <= 0) {
        NSLog(@"%@ can not attack %@. He is already dead!",self.name, enemy.name);
    }
    else{
        enemy.life = enemy.life - self.punchDamage;
        self.power = self.power + PUNCH_POWER;
        
        if (enemy.life <= 0) {
            NSLog(@"%@ killed %@!", self.name, enemy.name);
        }
        else{
            NSLog(@"%@ punched %@ with damage %d. %@ health left -> %d", self.name, enemy.name, self.punchDamage, enemy.name, enemy.life);
        }
    }
}

-(void) kickEnemy: (Hero*) enemy{
    if (enemy.life <= 0) {
        NSLog(@"%@ can not attack %@. He is already dead!",self.name, enemy.name);
    }
    else{
        enemy.life = enemy.life - self.punchDamage;
        self.power = self.power + KICK_POWER;
        
        if (enemy.life <= 0) {
            NSLog(@"%@ killed %@!", self.name, enemy.name);
        }
        else{
            NSLog(@"%@ kicked  %@ with damage %d. %@ health left -> %d", self.name, enemy.name, self.kickDamage, enemy.name, enemy.life);
        }
    }
}
@end
