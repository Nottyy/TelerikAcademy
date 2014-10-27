//
//  main.m
//  Objective-C Fundamentals
//
//  Created by Antonio on 10/26/14.
//  Copyright (c) 2014 Antonio. All rights reserved.
//

#import <Foundation/Foundation.h>

void printMatrix(NSArray *matrix) {
    NSMutableString *buffer = [[NSMutableString alloc] init];
    for (NSArray *row in matrix) {
        for (NSNumber *cell in row) {
            [buffer appendFormat:@"%3d", [cell intValue]];
        }
        [buffer appendString:@"\n"];
    }
    NSLog(@"\n%@", buffer);
}

NSArray* generateMatrix(int n){
    NSMutableArray *matrix = [[NSMutableArray alloc] initWithCapacity: 5];
    
    for (int i = 0; i < n; i++) {
        matrix[i] = [[NSMutableArray alloc] initWithCapacity: n];
        for (int j = 0; j < n; j++) {
            matrix[i][j] = [NSNull null];
        }
    }
    
    int r = 0;
    int c = 0;
    int offset = 0;
    int digit = 1;
    
    while (digit <= n*n)
    {
        //right
        r = offset;
        for (c = offset; c < n - offset; c++)
        {
            matrix[r][c] = [NSNumber numberWithInt:digit];
            digit++;
        }
        
        //down
        c = n - offset - 1;
        for (r = 1 + offset; r < n-offset; r++)
        {
            matrix[r][c] = [NSNumber numberWithInt:digit];
            digit++;
        }
        
        //left
        r = n - 1 - offset;
        for (c = n - 2 - offset; c >= offset; c--)
        {
            matrix[r][c] = [NSNumber numberWithInt:digit];
            digit++;
        }
        //up
        c = offset;
        for (r = n - 2 - offset; r >=offset + 1; r--)
        {
            matrix[r][c] = [NSNumber numberWithInt:digit];
            digit++;
        }
        
        offset++;
    }
    
    return matrix;
}

int main(int argc, const char * argv[]) {
    @autoreleasepool {
        NSArray *matrix = generateMatrix(3);
        printMatrix(matrix);
        
        matrix = generateMatrix(5);
        printMatrix(matrix);
        
        matrix = generateMatrix(7);
        printMatrix(matrix);
    }
    return 0;
    
}