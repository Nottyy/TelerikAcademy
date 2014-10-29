//
//  IFighting.h
//  MortalKombatGame
//
//  Created by Antonio on 10/29/14.
//  Copyright (c) 2014 Antonio Marinov. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "Hero.h"

@protocol IFighting <NSObject>

-(void) punchEnemy: (id) hero;
-(void) kickEnemy: (id) hero;
-(void) castSpellOnEnemy: (id) hero;

@property int power;
@end
