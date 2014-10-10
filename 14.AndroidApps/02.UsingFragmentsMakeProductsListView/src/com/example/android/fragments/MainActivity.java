package com.example.android.fragments;

import android.os.Bundle;
import android.support.v4.app.FragmentActivity;
import android.support.v4.app.FragmentTransaction;

public class MainActivity extends FragmentActivity 
        implements HeadlinesFragment.OnHeadlineSelectedListener {

    /** Called when the activity is first created. */
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.products_information);

        if (findViewById(R.id.fragment_container) != null) {
            HeadlinesFragment firstFragment = new HeadlinesFragment();
            getSupportFragmentManager().beginTransaction()
                    .add(R.id.fragment_container, firstFragment).commit();
        }
    }

    public void onproductSelected(int position) {
        ProductFragment productFrag = (ProductFragment)
                getSupportFragmentManager().findFragmentById(R.id.product_fragment);

        if (productFrag != null) {
            productFrag.updateproductView(position);

        } else {
            ProductFragment newFragment = new ProductFragment();
            Bundle args = new Bundle();
            args.putInt(ProductFragment.ARG_POSITION, position);
            newFragment.setArguments(args);
            FragmentTransaction transaction = getSupportFragmentManager().beginTransaction();

            transaction.replace(R.id.fragment_container, newFragment);
            transaction.addToBackStack(null);

            transaction.commit();
        }
    }
}