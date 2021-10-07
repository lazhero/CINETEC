package com.example.cinetec.ScreenApp;

import androidx.appcompat.app.AppCompatActivity;

import android.content.res.Resources;
import android.os.Bundle;
import android.util.TypedValue;
import android.view.ContextThemeWrapper;
import android.view.View;
import android.widget.LinearLayout;

import com.example.cinetec.R;
import com.example.cinetec.customviews.Matrix_layout;
import com.google.android.material.button.MaterialButton;

public class Seat_activity extends AppCompatActivity {
    Matrix_layout layout;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_seat);
        layout=(Matrix_layout) findViewById(R.id.seat_selecction_layout);
        set_matrix(10);
        justprove();

    }
    public void justprove(){
        for(int i=0;i<100;i++){
            add_free_seat();

        }


    }
    public void set_matrix(int rows){
        layout.setMax_per_row(rows);
    }

    public void add_free_seat(){
        MaterialButton button=create_seat();
        button.setIconTintResource(R.color.white);
        button.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View view) {
                highlight(button);
            }
        });

        layout.add_view(button);
    }
    public void add_occupied_seat(){
        MaterialButton button=create_seat();
        button.setIconTintResource(R.color.gray);
        button.setEnabled(false);
        layout.add_view(button);
    }
    public void add_selected_seat(){
        MaterialButton button=create_seat();
        button.setIconTintResource(R.color.yellow);

        button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                off(button);
            }
        });
        layout.add_view(button);
    }

    public void highlight(MaterialButton button){
        button.setIconTintResource(R.color.yellow);
        button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                off(button);
            }
        });

    }
    public void off(MaterialButton button){
        button.setIconTintResource(R.color.white);
        button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                highlight(button);
            }
        });
    }
    private MaterialButton create_seat(){
        int buttonStyle = R.style.free_seat;
        MaterialButton button = new MaterialButton(new ContextThemeWrapper(this, buttonStyle), null, buttonStyle);
        button.setBackgroundTintList(this.getResources().getColorStateList(R.color.black));
        button.setLayoutParams(new LinearLayout.LayoutParams(dp_px(33),dp_px(40)));
        return button;
    }

    private int dp_px(int measure){
        Resources r = this.getResources();
        int px = (int) TypedValue.applyDimension(
                TypedValue.COMPLEX_UNIT_DIP,
                measure,
                r.getDisplayMetrics()
        );
        return px;
    }
}