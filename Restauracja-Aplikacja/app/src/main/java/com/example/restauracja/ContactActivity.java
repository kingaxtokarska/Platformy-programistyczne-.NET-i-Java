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

import java.util.Locale;

import static com.example.restauracja.MainActivity.name_meal;

public class ContactActivity extends AppCompatActivity {

    Toolbar toolbar;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_contact);

        toolbar = findViewById(R.id.app_bar);
        toolbar.setTitle(R.string.contact);
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
        Intent menu = new Intent(ContactActivity.this, MenuActivity.class);
        Intent home = new Intent(ContactActivity.this, MainActivity.class);
        Intent reservation = new Intent(ContactActivity.this, ReservationActivity.class);
        Intent delivery = new Intent(ContactActivity.this, DeliveryActivity.class);
        Intent about = new Intent(ContactActivity.this, AboutUsActivity.class);
        Intent contact = new Intent(ContactActivity.this, ContactActivity.class);
        switch (item.getItemId())
        {
            case R.id.icon_pl:
                //icon_pl
                load_language("df");
                toolbar = findViewById(R.id.app_bar);
                toolbar.setTitle(R.string.contact);
                setSupportActionBar(toolbar);
                break;
            case R.id.icon_uk:
                //icon_uk
                load_language("en");
                toolbar = findViewById(R.id.app_bar);
                toolbar.setTitle(R.string.contact);
                setSupportActionBar(toolbar);
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
        ContactActivity.this.setContentView(R.layout.activity_contact);
    }


}
