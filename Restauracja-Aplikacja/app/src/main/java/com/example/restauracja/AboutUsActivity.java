package com.example.restauracja;

import androidx.annotation.NonNull;
import androidx.annotation.RequiresApi;
import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;

import android.content.Intent;
import android.content.res.Configuration;
import android.os.Build;
import android.os.Bundle;
import android.text.Layout;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.widget.TextView;

import java.util.Locale;

import static com.example.restauracja.MainActivity.name_meal;

public class AboutUsActivity extends AppCompatActivity {

    Toolbar toolbar;
    TextView description;

    @RequiresApi(api = Build.VERSION_CODES.O)
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_about_us);

        toolbar = findViewById(R.id.app_bar);
        toolbar.setTitle(R.string.about_us);
        setSupportActionBar(toolbar);

        description = findViewById(R.id.description);
        description.setJustificationMode(Layout.JUSTIFICATION_MODE_INTER_WORD);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.menu, menu);
        return super.onCreateOptionsMenu(menu);
    }

    @RequiresApi(api = Build.VERSION_CODES.O)
    @Override
    public boolean onOptionsItemSelected(@NonNull MenuItem item) {
        Intent menu = new Intent(AboutUsActivity.this, MenuActivity.class);
        Intent home = new Intent(AboutUsActivity.this, MainActivity.class);
        Intent reservation = new Intent(AboutUsActivity.this, ReservationActivity.class);
        Intent delivery = new Intent(AboutUsActivity.this, DeliveryActivity.class);
        Intent about = new Intent(AboutUsActivity.this, AboutUsActivity.class);
        Intent contact = new Intent(AboutUsActivity.this, ContactActivity.class);
        switch (item.getItemId())
        {
            case R.id.icon_pl:
                //icon_pl
                load_language("df");
                toolbar = findViewById(R.id.app_bar);
                toolbar.setTitle(R.string.about_us);
                setSupportActionBar(toolbar);
                description = findViewById(R.id.description);
                description.setJustificationMode(Layout.JUSTIFICATION_MODE_INTER_WORD);
                break;
            case R.id.icon_uk:
                //icon_uk
                load_language("en");
                toolbar = findViewById(R.id.app_bar);
                toolbar.setTitle(R.string.about_us);
                setSupportActionBar(toolbar);
                description = findViewById(R.id.description);
                description.setJustificationMode(Layout.JUSTIFICATION_MODE_INTER_WORD);
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
        AboutUsActivity.this.setContentView(R.layout.activity_about_us);
    }
}
