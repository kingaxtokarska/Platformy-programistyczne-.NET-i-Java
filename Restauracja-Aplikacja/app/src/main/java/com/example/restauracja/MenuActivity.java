package com.example.restauracja;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;

import android.content.Intent;
import android.content.res.Configuration;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.List;
import java.util.Locale;

import static com.example.restauracja.MainActivity.name_meal;

public class MenuActivity extends AppCompatActivity {

    Toolbar toolbar;
    TextView menu_meal;
    DatabaseHelper db;
    ListView menu_names, menu_prices;
    int num;
    Integer []menu_meals = {R.string.menu_starters, R.string.menu_soups, R.string.menu_salads, R.string.menu_pasta,
            R.string.menu_meats, R.string.menu_fishes, R.string.menu_desserts, R.string.menu_pizza};
    String []meals_pl = {"Przystawki", "Zupy", "Sałatki", "Makarony", "Mięsa", "Ryby", "Desery", "Pizze"};
    String []meals_en = {"Starters", "Soups", "Salads", "Pasta", "Meats", "Fishes", "Desserts", "Pizza"};

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_menu);

        db = new DatabaseHelper(this);

        toolbar = findViewById(R.id.app_bar);
        toolbar.setTitle(R.string.menu);
        setSupportActionBar(toolbar);

        menu_names = findViewById(R.id.menu_names);
        menu_prices = findViewById(R.id.menu_prices);

        menu_meal = findViewById(R.id.menu_meal);
        menu_meal.setText(name_meal);

        List<String> names = db.getLabels(name_meal, 1);
        List<String> prices = db.getLabels(name_meal, 2);
        List<String> rows_names = new ArrayList<>();
        List<String> rows_prices = new ArrayList<>();
        for(int i = 0; i < names.size(); i++) {
            rows_names.add(names.get(i));
            rows_prices.add(prices.get(i));
        }

        ArrayAdapter<String> adapter_rows_names = new ArrayAdapter<String>(this, android.R.layout.simple_list_item_1, rows_names){
            @Override
            public View getView(int position, View convertView, @NonNull ViewGroup parent) {
                View view = super.getView(position, convertView, parent);
                TextView text = view.findViewById(android.R.id.text1);
                text.setTextColor(getResources().getColor(R.color.White));
                return view;
            }
        };
        ArrayAdapter<String> adapter_rows_prices = new ArrayAdapter<String>(this, android.R.layout.simple_list_item_1, rows_prices){
            @Override
            public View getView(int position, View convertView, @NonNull ViewGroup parent) {
                View view = super.getView(position, convertView, parent);
                TextView text = view.findViewById(android.R.id.text1);
                text.setTextColor(getResources().getColor(R.color.White));
                return view;
            }
        };

        menu_names.setAdapter(adapter_rows_names);
        menu_prices.setAdapter(adapter_rows_prices);
        menu_names.setEnabled(false);
        menu_prices.setEnabled(false);

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
        Intent about = new Intent(MenuActivity.this, AboutUsActivity.class);
        Intent contact = new Intent(MenuActivity.this, ContactActivity.class);
        switch (item.getItemId())
        {
            case R.id.icon_pl:
                //icon_pl
                for(int i = 0; i < meals_en.length; i++) {
                    if(name_meal.equals(meals_en[i]) || name_meal.equals(meals_pl[i])) {
                        num = i;
                        break;
                    }
                }
                load_language("df");
                toolbar = findViewById(R.id.app_bar);
                toolbar.setTitle(R.string.menu);
                setSupportActionBar(toolbar);
                name_meal = getString(menu_meals[num]);
                startActivity(menu);
                break;
            case R.id.icon_uk:
                //icon_uk
                for(int i = 0; i < meals_en.length; i++) {
                    if(name_meal.equals(meals_en[i]) || name_meal.equals(meals_pl[i])) {
                        num = i;
                        break;
                    }
                }
                load_language("en");
                toolbar = findViewById(R.id.app_bar);
                toolbar.setTitle(R.string.menu);
                setSupportActionBar(toolbar);
                name_meal = getString(menu_meals[num]);
                startActivity(menu);
                break;
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
                name_meal = getString(R.string.menu_starters);
                startActivity(menu);
                break;
            case R.id.menu_soups:
                //menu_soups
                name_meal = getString(R.string.menu_soups);
                startActivity(menu);
                break;
            case R.id.menu_salads:
                //menu_salads
                name_meal = getString(R.string.menu_salads);
                startActivity(menu);
                break;
            case R.id.menu_pasta:
                //menu_pasta
                name_meal = getString(R.string.menu_pasta);
                startActivity(menu);
                break;
            case R.id.menu_meats:
                //menu_meats
                name_meal = getString(R.string.menu_meats);
                startActivity(menu);
                break;
            case R.id.menu_fishes:
                //menu_fishes
                name_meal = getString(R.string.menu_fishes);
                startActivity(menu);
                break;
            case R.id.menu_desserts:
                //menu_desserts
                name_meal = getString(R.string.menu_desserts);
                startActivity(menu);
                break;
            case R.id.menu_pizza:
                //menu_pizza
                name_meal = getString(R.string.menu_pizza);
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
            case R.id.about_us:
                //about us
                startActivity(about);
                break;
            case R.id.contact:
                //contact
                startActivity(contact);
                break;
            default:
                //unknown error
        }
        return super.onOptionsItemSelected(item);
    }

    public void load_language (String languageToLoad){
        Locale locale = new Locale(languageToLoad);
        Locale.setDefault(locale);
        Configuration config = new Configuration();
        config.locale = locale;
        getBaseContext().getResources().updateConfiguration(config,
                getBaseContext().getResources().getDisplayMetrics());
        MenuActivity.this.setContentView(R.layout.activity_menu);
    }


}
