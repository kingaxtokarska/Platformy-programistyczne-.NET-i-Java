package com.example.restauracja;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;

import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.GridView;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.List;

import static com.example.restauracja.DatabaseHelper.desserts;
import static com.example.restauracja.DatabaseHelper.fishes;
import static com.example.restauracja.DatabaseHelper.meats;
import static com.example.restauracja.DatabaseHelper.pasta;
import static com.example.restauracja.DatabaseHelper.pizza;
import static com.example.restauracja.DatabaseHelper.salads;
import static com.example.restauracja.DatabaseHelper.soups;
import static com.example.restauracja.DatabaseHelper.starters;
import static com.example.restauracja.MainActivity.name_meal;

public class MenuActivity extends AppCompatActivity {

    Toolbar toolbar;
    TextView menu_meal;
    GridView menu_names;
    DatabaseHelper db;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_menu);

        db = new DatabaseHelper(this);

        toolbar = findViewById(R.id.app_bar);
        toolbar.setTitle("Menu");
        setSupportActionBar(toolbar);

        menu_meal = findViewById(R.id.menu_meal);
        menu_names = findViewById(R.id.menu_names);

        menu_meal.setText(name_meal);

        List<String> names = db.getLabels(name_meal, 1);
        List<String> prices = db.getLabels(name_meal, 2);
        List<String> rows = new ArrayList<>();
        for(int i = 1; i < names.size(); i++) {
            rows.add(names.get(i));
            rows.add(prices.get(i));
        }

        ArrayAdapter<String> adapter_rows = new ArrayAdapter<String>(this, android.R.layout.simple_list_item_1, rows){
            @Override
            public View getView(int position, View convertView, ViewGroup parent) {
                View view = super.getView(position, convertView, parent);
                TextView text = (TextView) view.findViewById(android.R.id.text1);
                text.setTextColor(getResources().getColor(R.color.White));
                return view;
            }
        };
        menu_names.setNumColumns(2);
        //menu_names.setHorizontalSpacing(0);
        //menu_names.setVerticalSpacing(170);
        //menu_names.setColumnWidth(150);
        //menu_names.setMinimumWidth(200);
        menu_names.setAdapter(adapter_rows);



    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.menu, menu);
        return super.onCreateOptionsMenu(menu);
    }

    @Override
    public boolean onOptionsItemSelected(@NonNull MenuItem item) {
        Intent menu = new Intent(MenuActivity.this, MenuActivity.class);
        Intent home = new Intent(MenuActivity.this, MainActivity.class);
        Intent reservation = new Intent(MenuActivity.this, ReservationActivity.class);
        Intent delivery = new Intent(MenuActivity.this, DeliveryActivity.class);
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