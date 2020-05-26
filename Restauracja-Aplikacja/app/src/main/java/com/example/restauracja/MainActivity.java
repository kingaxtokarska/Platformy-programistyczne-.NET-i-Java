package com.example.restauracja;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;

import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;

import static com.example.restauracja.DatabaseHelper.starters;
import static com.example.restauracja.DatabaseHelper.soups;
import static com.example.restauracja.DatabaseHelper.salads;
import static com.example.restauracja.DatabaseHelper.pasta;
import static com.example.restauracja.DatabaseHelper.meats;
import static com.example.restauracja.DatabaseHelper.fishes;
import static com.example.restauracja.DatabaseHelper.desserts;
import static com.example.restauracja.DatabaseHelper.pizza;

public class MainActivity extends AppCompatActivity {

    public static String name_meal = "";
    Toolbar toolbar;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        toolbar = findViewById(R.id.app_bar);
        toolbar.setTitle("Strona główna");
        setSupportActionBar(toolbar);


    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.menu, menu);
        return super.onCreateOptionsMenu(menu);
    }

    @Override
    public boolean onOptionsItemSelected(@NonNull MenuItem item) {
        Intent menu = new Intent(MainActivity.this, MenuActivity.class);
        Intent home = new Intent(MainActivity.this, MainActivity.class);
        Intent reservation = new Intent(MainActivity.this, ReservationActivity.class);
        Intent delivery = new Intent(MainActivity.this, DeliveryActivity.class);
        switch (item.getItemId())
        {
            case R.id.home:
                //home
                startActivity(home);
                break;
            case R.id.menu:
                //menu
                //startActivity(menu);
                break;
            case R.id.menu_starters:
                //menu_starters
                name_meal = starters;
                startActivity(menu);
                break;
            case R.id.menu_soups:
                //menu_soups
                name_meal = soups;
                startActivity(menu);
               break;
            case R.id.menu_salads:
                //menu_salads
                name_meal = salads;
                startActivity(menu);
                break;
            case R.id.menu_pasta:
                //menu_pasta
                name_meal = pasta;
                startActivity(menu);
                break;
            case R.id.menu_meats:
                //menu_meats
                name_meal = meats;
                startActivity(menu);
                break;
            case R.id.menu_fishes:
                //menu_fishes
                name_meal = fishes;
                startActivity(menu);
                break;
            case R.id.menu_desserts:
                //menu_desserts
                name_meal = desserts;
                startActivity(menu);
                break;
            case R.id.menu_pizza:
                //menu_pizza
                name_meal = pizza;
                startActivity(menu);
                break;
            case R.id.reservation:
                //reservation
                startActivity(reservation);
                break;
            case R.id.delivery:
                //delivery
                startActivity(delivery);
                break;
            default:
                //unknown error
        }
        return super.onOptionsItemSelected(item);
    }
}
